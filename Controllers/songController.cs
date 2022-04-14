namespace _321mis_pa4.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class songController : ControllerBase
    {
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            IGetAllSongs readObject = new ReadSongData();
            return readObject.GetAllSongs();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{SongID}", Name = "Get")]
        public Song Get(int SongID)
        {
            IGetSong readObject = new ReadSongData();
            Console.WriteLine(SongID);
            return readObject.GetSong(SongID);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostSong")]
        public void Post(Song song)
        {
            IInsertSong insertObject = new AddSong();
            insertObject.InsertSong(song);
        }
        
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put([FromBody] Song song)  //used to have [From Body] before Song
        {
            IEditSongs editObject = new EditSongData();
            editObject.Edit(song);
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