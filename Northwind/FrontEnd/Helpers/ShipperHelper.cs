using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ShipperHelper
    {
        ServiceRepository repository;

        public ShipperHelper()
        {
            repository = new ServiceRepository();
        }

        public List<ShipperViewModel> GetAll()
        {

            List<ShipperViewModel> lista = new List<ShipperViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Shipper/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);
            }

            return lista;
        }

        /// <summary>
        /// Get category By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShipperViewModel GetById(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Shipper/" + id);
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipper;
        }

    }
}
