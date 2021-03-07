using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ViewModels;
using System.Net;
using System.Threading;
using System.Net.Http;
using System.Text.Json;

namespace API.Base.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var result = repository.Get();

            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Ditemukan" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, result, message = "Terjadi Kesalahan" }); ;
            }
        }

        [HttpGet("{key}")]
        public ActionResult<Entity> Get(Key key)
        {
            var result = repository.Get(key);
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Ditemukan" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan" });
            }
        }
        
        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            var result = repository.Insert(entity);
            if (result > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Berhasil Membuat Data Baru" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Membuat Data Baru" });
            }
        }

        [HttpDelete]
        public ActionResult Delete(Entity entity)
        {
            var result = repository.Delete(entity);
            if (result > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Berhasil Menghapus Data Baru" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Menghapus Data Baru" });
            }
        }

        [HttpPut]
        public ActionResult Put(Entity entity)
        {
            if (entity == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Yang Di-Input Salah / Tidak Lengkap" });
            }

            var result = repository.Update(entity);

            if (result > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "Berhasil Update Data" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Update Data" });
            }
        }
    }
}

