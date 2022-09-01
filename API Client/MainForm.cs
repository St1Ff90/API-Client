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
            PanelPostDetales.Visible = false;
            panelBotom.Visible = false;
            btnAddNew.Visible = false;
        }

        #region SharedMethods

        private async Task GetObjByPage<T>(int page)
        {
            using (_myClient)
            {
                var list = await _myClient.GetListObjAsync<T>(page);
                CleanDGW();
                CreateDataTable(list);
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

        private void CleanDGW()
        {
            if (dgwMain.Columns["Edit"] != null)
            {
                dgwMain.Columns.Remove("Edit");
            }
            if (dgwMain.Columns["Delete"] != null)
            {
                dgwMain.Columns.Remove("Delete");
            }
        }

        #endregion

        #region UserMethods
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

            await GetObjByPage<DTO.User>(_myClient.currentPage);
        }

        #endregion

        #region PostMethods

        private void FillPostTextBoxes(Post data)
        {
            PanelPostDetales.Visible = true;
            tbUserId.Text = data.UserId.ToString();
            tbTitle.Text = data.Title;
            tbBody.Text = data.Body;

        }
        private async void button1_Click(object sender, EventArgs e)
        {

            List<DTO.Error>? errors = new List<Error>();

            DTO.Post post = new Post()
            {
                UserId = Convert.ToInt16(tbUserId.Text),
                Title = tbTitle.Text,
                Body = tbBody.Text
            };

            if (_objId == 0)
            {
                errors = await _myClient.PostObjAsync<DTO.Post>(post);
            }
            else
            {
                errors = await _myClient.PatchObjAsync<DTO.Post>(post, _objId);
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

            PanelPostDetales.Visible = false;
            tbUserId.Text = "";
            tbTitle.Text = "";
            tbBody.Text = "";


            await GetObjByPage<DTO.Post>(_myClient.currentPage);
        }
        #endregion

        #region Interface
        private async void llUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            typeOfObj = "user";
            await GetObjByPage<DTO.User>(1);
            btnAddNew.Visible = true;
            btnAddNew.Text = "Add new user";
            CleanDGW();
        }

        private async void llPosts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            typeOfObj = "post";
            await GetObjByPage<DTO.Post>(1);
            btnAddNew.Visible = true;
            btnAddNew.Text = "Add new post";
            CleanDGW();
        }

        private async void btnAddNew_Click(object sender, EventArgs e)
        {
            _objId = 0;
            switch (typeOfObj)
            {
                case "user":
                    FillUserTextBoxes(new User());
                    break;
                case "post":
                    FillPostTextBoxes(new Post());
                    break;

                default:
                    break;
            }
        }

        private async void dgwMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwMain.Columns[e.ColumnIndex].Name == "Edit")
            {
                _objId = Convert.ToInt32(dgwMain[dgwMain.Columns["Id"].Index, e.RowIndex].Value);

                using (_myClient)
                {
                    switch (typeOfObj)
                    {
                        case "user":
                            var data = await _myClient.GetObjAsync<DTO.User>(_objId);
                            FillUserTextBoxes(data);
                            break;
                        case "post":
                            var post = await _myClient.GetObjAsync<DTO.Post>(_objId);
                            FillPostTextBoxes(post);
                            break;
                        default:
                            break;
                    }
                }
            }
            if (dgwMain.Columns[e.ColumnIndex].Name == "Delete")
            {
                var myErrors = new List<DTO.Error>();
                _objId = Convert.ToInt32(dgwMain[dgwMain.Columns["Id"].Index, e.RowIndex].Value);

                using (_myClient)
                {

                    switch (typeOfObj)
                    {
                        case "user":
                            myErrors = await _myClient.DeleteObjAsync<DTO.User>(_objId);
                            await GetObjByPage<DTO.User>(_myClient.currentPage);
                            break;
                        case "post":
                            myErrors = await _myClient.DeleteObjAsync<DTO.Post>(_objId);
                            await GetObjByPage<DTO.Post>(_myClient.currentPage);
                            break;
                        default:
                            break;
                    }
                }

                if (myErrors != null)
                {
                    string Errors = "";
                    foreach (var item in myErrors)
                    {
                        Errors += item.Field + " " + item.Message;
                    }
                    MessageBox.Show(Errors);
                }
            }
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(lblCurrentPage.Text);
            if (_myClient.totalPages > currentPage)
            {
                switch (typeOfObj)
                {
                    case "user":
                        GetObjByPage<DTO.User>(currentPage + 1);
                        break;
                    case "post":
                        GetObjByPage<DTO.Post>(currentPage + 1);
                        break;
                    default:
                        break;
                }
            }
        }

        private void PrevPage_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(lblCurrentPage.Text);
            if (currentPage > 1)
            {
                switch (typeOfObj)
                {
                    case "user":
                        GetObjByPage<DTO.User>(currentPage - 1);
                        break;
                    case "post":
                        GetObjByPage<DTO.Post>(currentPage - 1);
                        break;
                    default:
                        break;
                }
            }
        }



        #endregion


    }
}