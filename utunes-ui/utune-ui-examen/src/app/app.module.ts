import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlbumFilterComponent } from './album-filter/album-filter.component';
import { SongComponent } from './song/song.component';
import { SongService } from './services/song.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    AlbumFilterComponent,
    SongComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [SongService],
  bootstrap: [AppComponent]
})
export class AppModule { }
