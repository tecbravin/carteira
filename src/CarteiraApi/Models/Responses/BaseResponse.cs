﻿using System.Text.Json.Serialization;

namespace CarteiraApi.Models.Responses
{
    public class BaseResponse
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public int? CreatedId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
