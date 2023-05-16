import { Component, Input } from '@angular/core';
import { Song } from '../Models/song';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent {

  @Input() song?: Song;

  constructor(){}

  ngOnInit(): void {}

  


}
