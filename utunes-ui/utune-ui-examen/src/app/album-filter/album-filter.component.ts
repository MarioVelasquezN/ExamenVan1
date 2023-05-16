import { Component, EventEmitter, Output } from '@angular/core';
import { SongService } from '../services/song.service';
import { Album } from '../Models/album';

@Component({
  selector: 'app-album-filter',
  templateUrl: './album-filter.component.html',
  styleUrls: ['./album-filter.component.css']
})
export class AlbumFilterComponent {

  albums!: Album[];
  constructor(private songService: SongService) { 
    this.songService.getAlbums()
    .subscribe({
      next:(data:Album[]) => {
        this.albums = data;
      },
      error:err=>console.log(err)
      
    })
  }

  @Output() changed=new EventEmitter<number>();
  ngOnInit(): void {
  }

  onChange(target:any):void{
    this.changed.emit(+target.value);
  }
}
