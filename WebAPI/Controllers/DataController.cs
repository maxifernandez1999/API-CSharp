using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;
using System.IO;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DataController : ApiController
    {
        // GET: api/data
        string path = @"C:\json\data.json";
        public IHttpActionResult Get()
        {
            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(this.path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var data = JsonConvert.DeserializeObject<List<Person>>(jsonFromFile);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest("Ocurrio un error");
            }

        }

        

        // POST api/Shipper
        [HttpPost]
        public IHttpActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(this.path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var data = JsonConvert.DeserializeObject<List<Person>>(jsonFromFile);
                data.Add(person);
                string serialize = JsonConvert.SerializeObject(data.ToArray(), Formatting.Indented);
                File.WriteAllText(this.path, serialize);
                return Ok("Insertado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest("Ocurrio un error");
            }

        }

        // PUT api/Shipper/5

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (id == null) { return BadRequest("El ID de la URL es nulo"); }

            //if (shipper.ShipperID != id) { return BadRequest("El ID del body no coincide con el ID de la URL"); }

            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(this.path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var data = JsonConvert.DeserializeObject<List<Person>>(jsonFromFile);
                foreach (var per in data)
                {
                    if (per.Id == id)
                    {
                        data.Remove(per);
                        data.Add(person);
                        string serialize = JsonConvert.SerializeObject(data.ToArray(), Formatting.Indented);
                        File.WriteAllText(this.path, serialize);
                        return Ok("Modlificado");
                    }
                }
                return Ok("Actualizado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest("Ocurrio un error");
            }
        }

        // DELETE api/Shipper/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id == null) { return NotFound(); }

            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(this.path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var data = JsonConvert.DeserializeObject<List<Person>>(jsonFromFile);
                foreach (var per in data)
                {
                    if (per.Id == id)
                    {
                        data.Remove(per);
                        string serialize = JsonConvert.SerializeObject(data.ToArray(), Formatting.Indented);
                        File.WriteAllText(this.path, serialize);
                        return Ok("Eliminado");
                    }
                }
                return Ok("Eliminado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest("Ocurrio un error");
            }
        }
    }
}
