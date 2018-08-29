using System;
using System.Threading.Tasks;
using NetCore.Entities.Request;
using NetCore.Services;
using Newtonsoft.Json;
using Xunit;

namespace NetCore.Test {
    public class UnitTest {
        Service _service = null;

        [Fact]
        public async Task jsonplaceholderTodoService () {
            _service = new Service (url: "https://jsonplaceholder.typicode.com/todos");
            var responseGet = await _service.Get();
            var responseGetById = await _service.Get("2");

            var TodoList = JsonConvert.DeserializeObject<Todo[]> (responseGet.ToString ());
            var Todo = JsonConvert.DeserializeObject<Todo> (responseGetById.ToString ());

            Assert.Equal (TodoList.Length, 200);
            Assert.NotNull (TodoList);
            Assert.Equal (Todo.Id, 2);
            Assert.NotNull (Todo);
        }

        [Fact]
        public async Task FrameworksList () {
            _service = new Service (url: "https://raw.githubusercontent.com/jmbl1685/diskdb-sample-nodejs/master/data/frameworks.json");
            var responseGet = await _service.Get ();
            var FrameworkList = JsonConvert.DeserializeObject<Framework[]> (responseGet.ToString ());
            Assert.Equal (FrameworkList.Length, 6);
            Assert.NotNull (FrameworkList);
        }

        [Fact]
        public async Task HerokuCarService () {

            /* 
                _service = new Service (url: "https://vehicosta-backend.herokuapp.com/car");

                Car car = new Car () {
                    Color = "Red",
                    Trademark = "Chevrolet",
                    Model = "Camaro SS",
                    Price = 740200,
                    Quantity = 10,
                    Image = "http://i.ebayimg.com/00/s/NTAwWDUwMA==/z/AVcAAOSw0e9UyASP/$_3.JPG?set_id=2"
                };

                string id = "407a8223-2674-43e3-b265-7dfbe20f04a0";

                var responseGetById = await _service.Get (id);

                var responseGet = await _service.Get ();

                var responsePost = await _service.Post (car);

                var responsePut = await _service.Put (id, car);

                var responseDelete = await _service.Delete (id);

                Assert.DoesNotContain (responseGetById.ToString (), "{\"data\":\"No Encontrado\",\"status\":400}");
                Assert.DoesNotContain (responseGet.ToString (), "Cannot GET /car");
                Assert.DoesNotContain (responsePost.ToString (), "Cannot GET /car");
                Assert.Contains (responsePost.ToString (), "{\"data\":\"Creado correctamente\",\"status\":200}");
                Assert.DoesNotContain (responsePut.ToString (), "Cannot GET /car");
                Assert.DoesNotContain (responseDelete.ToString (), "{\"data\":\"No Encontrado\",\"status\":400}");
            */
        }

    }

}