import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Song } from '../Models/song';
import { Album } from '../Models/album';

@Injectable({
  providedIn: 'root'
})
export class SongService {

  constructor(private httpClient: HttpClient) { }

  getSongs(albumId:number):Observable<Song[]>{
    return this.httpClient.get<Song[]>(`${environment.baseApiUrl}/api/songs/${albumId}`);
  }

  getAlbums():Observable<Album[]>{
    return this.httpClient.get<Album[]>(`${environment.baseApiUrl}/api/albums`);

  }
}
