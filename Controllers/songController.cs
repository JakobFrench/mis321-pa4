//namespace _321mis_pa4.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using PA3.Models;
using PA3.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class songController
    {
        [EnableCors("Another")]
        [HttpGet]
        public List<Song> Get()
        {
            IReadSongs readObject = new GetAll();
            return readObject.GetAll();
        }

        [EnableCors("Another")]
        [HttpGet("{SongID}", id = "fav")]
        public Song Get(int SongID)
        {
            IReadSongs readObject = new GetAll();
            Console.WriteLine(SongID);
            return readObject.GetAll(SongID);
        }

        [EnableCors("Another")]
        [HttpPost(id = "add")]
        public void Post(Song song)
        {
            ICreateSongs insertObject = new Create();
            insertObject.Create(song);
        }
        
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put([FromBody] Song song)  //used to have [From Body] before Song
        {
            IUpdateSongs editObject = new Update();
            editObject.Update(song);
        }

        [EnableCors("AnotherPolicy")]
        [HttpDelete("{SongID}")]
        public void Delete(int SongID)
        {
            IDeleteSongs deleteObject = new RemoveSong();
            deleteObject.DeleteSong(SongID);
        }
    }
}