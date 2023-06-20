using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private IShipperDAL shipperDal;

        #region Constructores
        public ShipperController()
        {
            shipperDal = new ShipperDALImpl();
        }

        #endregion

        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = shipperDal.GetAll();

            return new JsonResult(shippers);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper = shipperDal.Get(id);

            return new JsonResult(shipper);
        }

        #endregion

        // POST api/<ShipperController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
