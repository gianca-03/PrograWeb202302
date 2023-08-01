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

       
        public ShipperViewModel GetById(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Shipper/" + id);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipper;
        }

        #region Update
        public ShipperViewModel Edit(ShipperViewModel shipper)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/Shipper/", shipper);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ShipperViewModel shipperAPI = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            return shipperAPI;

        }
        #endregion

        #region Create
        public ShipperViewModel Add(ShipperViewModel shipper)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/Shipper/", shipper);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ShipperViewModel shipperAPI = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            return shipperAPI;

        }
        #endregion


        #region Delete
        public ShipperViewModel Delete(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Shipper/" + id);            

            return shipper;

        }
        #endregion
    }
}
