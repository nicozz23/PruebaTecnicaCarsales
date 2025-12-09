// src/app/models/episode.model.ts
import { BaseEntity, BffResponse } from './common.model';

export interface Episode extends BaseEntity { // <-- HEREDA
  // id y name ya están en BaseEntity
  code: string;       
  airDate: string;
  url: string;
}
// Interfaz final de respuesta para Episodios
export interface EpisodeBffResponse extends BffResponse<Episode> {}



