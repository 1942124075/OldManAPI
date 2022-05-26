using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OldManAPI.Model;
using System.Data.SqlClient;

namespace OldManAPI.Controllers
{
    [ApiController]
    [Route("GetResources")]
    public class GetResources : Controller
    {
        [HttpGet(Name = "GetResources")]
        public string Get(string category)
        {
            SqlConnection sqlConnection = BaseHelper.GetConnect();
            SqlCommand sqlCommand = new SqlCommand("SELECT ID ,NAME ,IMAGE,ContentS FROM BaseList WHERE CATEGORY = @category", sqlConnection);
            sqlCommand.Parameters.AddWithValue("category", category);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            BaseInfo baseInfo;
            List<BaseInfo> baseList = new List<BaseInfo>();
            while (sqlDataReader.Read())
            {
                baseInfo = new BaseInfo()
                {
                    Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ID")),
                    Name = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("NAME")) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("NAME")),
                    Image = BaseHelper.WebPrefix + (sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("IMAGE")) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("IMAGE"))),
                    Content = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("ContentS")) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("ContentS"))
                };
                baseList.Add(baseInfo);
            }
            return JsonConvert.SerializeObject(baseList);
        }
    }
}
