// src/app/models/location.model.ts
import { BaseEntity, BffResponse } from './common.model';

export interface Location extends BaseEntity { // <-- HEREDA
  // id y name ya están en BaseEntity
  type: string;
  dimension: string;
  url: string;
  created: string;
}

// Interfaz final de respuesta para Locaciones
export interface LocationBffResponse extends BffResponse<Location> {}