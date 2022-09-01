using DTO;
using System.Data;
using System.Reflection;

namespace API_Client
{
    public partial class MainForm : Form
    {
        private DataTable _dataTable;
        private DataSet _dataSet;
        private string typeOfObj;
        MyClient _myClient = MyClient.GetInstance();
        private int _objId = 0;

        public MainForm()
        {
            InitializeComponent();
            PanelUserDetales.Visible = false;
            panelBotom.Visible = false;
            btnAddNew.Visible = false;
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await GetUserByPage(1);
            btnAddNew.Visible = true;
            btnAddNew.Text = "Add new user";
        }

        private async Task GetUserByPage(int page)
        {
            using (_myClient)
            {
                var data = await _myClient.GetListObjAsync<DTO.User>(page);
                CreateDataTable(data);
                typeOfObj = "user";
                lblCurrentPage.Text = page.ToString();
                panelBotom.Visible = true;
            }
        }

        private void CreateDataTable<T>(List<T> list)
        {
            if (list != null && list.Count > 0)
            {
                var type = list.First().GetType();
                _dataTable = new DataTable();
                _dataSet = new DataSet();
                _dataTable = _dataSet.Tables.Add(type.Name);

                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                if (properties.Count() > 0)
                {
                    foreach (var property in properties)
                    {
                        _dataTable.Columns.Add(property.Name, property.PropertyType);
                    }
                }

                dgwMain.DataSource = bsMain;
                bsMain.DataSource = _dataSet;
                bsMain.DataMember = _dataTable.TableName;

                foreach (var item in list)
                {
                    object[] row = new object[properties.Length];
                    for (int i = 0; i < properties.Length; i++)
                    {
                        row[i] = item.GetType().GetProperty(properties[i].Name).GetValue(item, null);
                    }
                    _dataTable.Rows.Add(row);
                }

                if (dgwMain.Columns["Edit"] == null)
                {
                    dgwMain.Columns.Insert(properties.Length, new DataGridViewButtonColumn() { Name = "Edit", Text = "Edit", UseColumnTextForButtonValue = true });
                }
                if (dgwMain.Columns["Delete"] == null)
                {
                    dgwMain.Columns.Insert(properties.Length + 1, new DataGridViewButtonColumn() { Name = "Delete", Text = "Delete", UseColumnTextForButtonValue = true });
                }

                dgwMain.Columns["Id"].Visible = false;
            }
        }

        private async void dgwMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwMain.Columns[e.ColumnIndex].Name == "Edit")
            {
                using (_myClient)
                {
                    switch (typeOfObj)
                    {
                        case "user":
                            _objId = Convert.ToInt32(dgwMain[dgwMain.Columns["Id"].Index, e.RowIndex].Value);
                            var data = await _myClient.GetObjAsync<DTO.User>(_objId);
                            FillUserTextBoxes(data);
                            break;
                        default:
                            break;
                    }
                }
            }
            if (dgwMain.Columns[e.ColumnIndex].Name == "Delete")
            {
                using (_myClient)
                {
                    switch (typeOfObj)
                    {
                        case "user":
                            _objId = Convert.ToInt32(dgwMain[dgwMain.Columns["Id"].Index, e.RowIndex].Value);
                            var data = await _myClient.DeleteObjAsync<DTO.User>(_objId);
                            if (data != null)
                            {
                                string Errors = "";
                                foreach (var item in data)
                                {
                                    Errors += item.Field + " " + item.Message;
                                }
                                MessageBox.Show(Errors);
                            }
                            await GetUserByPage(_myClient.currentPage);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void FillUserTextBoxes(User data)
        {
            PanelUserDetales.Visible = true;
            tbName.Text = data.Name;
            tbEmail.Text = data.Email;
            cbGeender.Items.AddRange(new string[] { "male", "female" });
            cbGeender.SelectedItem = data.Gender;
            cbStatus.Items.AddRange(new string[] { "active", "inactive" });
            cbStatus.SelectedItem = data.Status;
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(lblCurrentPage.Text);

            switch (typeOfObj)
            {
                case "user":
                    if (_myClient.totalPages > currentPage)
                    {
                        GetUserByPage(currentPage + 1);
                    }
                    break;

                default:
                    break;

            }
        }

        private void prevPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(lblCurrentPage.Text);

            switch (typeOfObj)
            {
                case "user":
                    if (currentPage > 1)
                    {
                        GetUserByPage(currentPage - 1);
                    }
                    break;

                default:
                    break;
            }
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            List<DTO.Error>? errors = new List<Error>();

            DTO.User user = new User()
            {
                Email = tbEmail.Text,
                Name = tbName.Text,
                Gender = cbGeender.Text,
                Status = cbStatus.Text
            };

            if (_objId == 0)
            {
                errors = await _myClient.PostObjAsync<DTO.User>(user);
            }
            else
            {
                errors = await _myClient.PatchObjAsync<DTO.User>(user, _objId);
                _objId = 0;
            }

            if (errors != null)
            {
                string Errors = "";
                foreach (var item in errors)
                {
                    Errors += item.Field + " " + item.Message;
                }
                MessageBox.Show(Errors);
            }

            PanelUserDetales.Visible = false;
            tbName.Text = "";
            tbEmail.Text = "";
            cbGeender.Items.Clear();
            cbStatus.Items.Clear();

            await GetUserByPage(_myClient.currentPage);
        }

        private async void btnAddNew_Click(object sender, EventArgs e)
        {
            switch (typeOfObj)
            {
                case "user":

                    FillUserTextBoxes(new User());
                    break;

                default:
                    break;

            }
        }
    }
}