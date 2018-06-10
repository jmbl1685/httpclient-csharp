using NetCore.Entities.Request;
using NetCore.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NetCore.Test
{
    public class UnitTest
    {
        Service _service = new Service(url: "https://vehicosta-backend.herokuapp.com/car");

        Car car = new Car()
        {
            Color = "Red",
            Trademark = "Chevrolet",
            Model = "Camaro SS",
            Price = 740200,
            Quantity = 10,
            Image = "http://i.ebayimg.com/00/s/NTAwWDUwMA==/z/AVcAAOSw0e9UyASP/$_3.JPG?set_id=2"
        };

        string id = "407a8223-2674-43e3-b265-7dfbe20f04a0";

        [Fact]
        public async Task TestServiceResponse()
        {

            var responseGetById = await _service.Get(id);

            var responseGet = await _service.Get();

            var responsePost = await _service.Post(car);

            var responsePut = await _service.Put(id, car);

            var responseDelete = await _service.Delete(id);

            Assert.DoesNotContain(responseGetById.ToString(), "{\"data\":\"No Encontrado\",\"status\":400}");
            Assert.DoesNotContain(responseGet.ToString(), "Cannot GET /car");
            Assert.DoesNotContain(responsePost.ToString(), "Cannot GET /car");
            Assert.Contains(responsePost.ToString(), "{\"data\":\"Creado correctamente\",\"status\":200}");
            Assert.DoesNotContain(responsePut.ToString(), "Cannot GET /car");
            Assert.DoesNotContain(responseDelete.ToString(), "{\"data\":\"No Encontrado\",\"status\":400}");

        }

    }
}
