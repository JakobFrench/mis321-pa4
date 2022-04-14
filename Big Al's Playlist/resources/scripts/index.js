function findSongs(){
    var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    let searchString = document.getElementById("searchSong").value;

    url += searchString;

    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
		json.forEach((song) => {
            console.log(song.title)
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">`+song.title+`</h5>`;
            html += `</div>`;
            html += `</div>`;
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})

    function postSong(){
        const postSongApiUrl = "https:"
    }
}

function postSong(){
    const postSongApiUrl = "https://localhost:5001/api/post";
    
    const title = {
        SongTitle: document.getElementById("title").value}
    fetch(url,{
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(title)
    })
    .then((response)=>{
        findSongs();
    })
}

function populateList(){
    const allSongsApiUrl = "https://localhost:5001/api/post";

}

function deleteSong(){
    let id = document.getElementById("deleteSong").value;
    const url = "https://localhost:5001/api/post"+id;
    fetch(url,{
        method: "DELETE",
        headers: {
            "Content-Type": 'application/json',
        },
    })
    .then((response)=>{
        findSongs();
    })
}

function favSong(){
    let id = document.getElementById("favSong").value;
    const url = "https://localhost:5001/api/post"+id;

    fetch(url, {
        method: "PUT",
        headers: {
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(title)
    })
    .then((response)=>{
        findSongs();
    })
}