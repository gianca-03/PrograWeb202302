using BackEnd.Models;
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

        private ShipperModel Convertir(Shipper shipper)
        {
            return (new ShipperModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone= shipper.CompanyName,
                Picture = shipper.Picture
            });
        }

        private Shipper Convertir(ShipperModel shipper)
        {
            return (new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.CompanyName,
                Picture = shipper.Picture
            });
        }

        #region Constructores
        public ShipperController()
        {
            shipperDal = new ShipperDALImpl();
        }

        #endregion

        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public async Task <JsonResult> Get()
        {
            IEnumerable<Shipper> shippers = await shipperDal.GetAll();
            List<ShipperModel> models = new List<ShipperModel>();

            foreach (var shipper in shippers)
            {
                models.Add(Convertir(shipper));
            }

            return new JsonResult(models);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public async Task <JsonResult> Get(int id)
        {
            Shipper shipper = await shipperDal.Get(id);

            return new JsonResult(shipper);
        }

        #endregion

        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] ShipperModel shipper)
        {
            shipperDal.Add(Convertir(shipper));
            return new JsonResult(shipper);
        }

        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ShipperModel shipper)
        {
            shipperDal.Update(Convertir(shipper));
            return new JsonResult(shipper);
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Shipper shipper= new Shipper
            {
                ShipperId= id
            };

            shipperDal.Remove(shipper);

        }
    }
}
