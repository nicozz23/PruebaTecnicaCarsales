import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EpisodeBffResponse } from '../models/episode';
import { CharacterBffResponse } from '../models/character';
import { LocationBffResponse } from '../models/location';

@Injectable({
  providedIn: 'root'
})
export class DataService {


private baseUrl = 'https://localhost:7094/api';

  constructor(private http: HttpClient) { }


getEpisodes(page: number): Observable<EpisodeBffResponse> {
    return this.http.get<EpisodeBffResponse>(`${this.baseUrl}/Episodes?page=${page}`);
  }

  getCharacters(page: number): Observable<CharacterBffResponse> {
    return this.http.get<CharacterBffResponse>(`${this.baseUrl}/Character?page=${page}`);
  }

  getLocations(page: number): Observable<LocationBffResponse> {
    return this.http.get<LocationBffResponse>(`${this.baseUrl}/Locations?page=${page}`);
  }

}
