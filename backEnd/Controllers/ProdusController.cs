using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using backEnd.Models;
using Dapper;


namespace backEnd.Controllers
{
    //[Route("api/produs")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdusController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ProdusController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //string query = @"select * from dbo.Produs where ProdusId=@ProdusId";
        [HttpGet]
        public IActionResult Get()
        {
            var ProdusId = 1;
            string query = @"select * from dbo.Produs";
            string sqlDataSrouce = _configuration.GetConnectionString("ProductAppCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSrouce))
            {
                myCon.Open();

                return this.Ok(myCon.Query<Produs>(query, new { ProdusId }).ToList());


            }




            //    string query = @"select * from dbo.Produs";
            //DataTable table = new DataTable();
            //string sqlDataSrouce = _configuration.GetConnectionString("ProductAppCon");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSrouce))
            //{
            //    myCon.Open();
            //    using (SqlCommand myComamand = new SqlCommand(query, myCon))

            //    {
            //        myReader = myComamand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        myCon.Close();
            //    }
            //}
            //return new JsonResult(table);
        }



        [HttpPut]
        public JsonResult Put([FromBody]Produs prod)
        {
            string query = @"
                     update dbo.Produs set   
                      NumeProdus = @NumeProdus
                     ,Categorie = @Categorie
                     ,Producator = @Producator
                     ,Pret = @Pret
                     ,Stoc = @Stoc
                     where ProdusId = @ProdusId";


            string sqlDataSrouce = _configuration.GetConnectionString("ProductAppCon");
            using (SqlConnection myCon = new SqlConnection(sqlDataSrouce))
            {
                myCon.Open();


                myCon.Execute(query,  prod);



                //using (SqlCommand myComamand = new SqlCommand(query, myCon))
                //{
                //    myComamand.CommandType = CommandType.Text;
                //    myComamand.ExecuteNonQuery();
                //}
                //myCon.Close();
            }
            return new JsonResult("Updated Successfully");
        }



    }
}
