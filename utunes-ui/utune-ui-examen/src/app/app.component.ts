import { Component, OnInit } from '@angular/core';
import { Song } from './Models/song';
import { SongService } from './services/song.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent  implements OnInit{

  title = 'utune';
  songs!:Array<Song>;
  filteredSongs!:Array<Song>;
  selectedSong!: Song;
  constructor(private SongService: SongService) { }

  ngOnInit(): void{
    this.SongService.getSongs(1).subscribe({
      next:(data:Song[]) => {
      this.songs = data;
      this.filteredSongs = this.songs;
      },
      error:(err:any) => console.log(err)
    });
  }

  onclick(song:Song):void{
    this.selectedSong = song;
  }

  filterByAlbum(albumId:number):void{
    if(albumId == 0){
      this.filteredSongs = this.songs;
      return;
    }
    this.filteredSongs = this.songs.filter((song:Song) => song.albumId == albumId);
  }
}
