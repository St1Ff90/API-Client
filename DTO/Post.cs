using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class Post
    {
        public int Id { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
