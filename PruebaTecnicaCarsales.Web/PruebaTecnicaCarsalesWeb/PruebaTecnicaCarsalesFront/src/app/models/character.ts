// src/app/models/character.model.ts
import { BaseEntity, BffResponse } from './common.model';

export interface Character extends BaseEntity { // <-- HEREDA
  // id y name ya están en BaseEntity
  status: string;
  species: string;
  locationName: string;
  imageUrl: string;
  gender: string;

}

// Interfaz final de respuesta para Personajes
export interface CharacterBffResponse extends BffResponse<Character> {}