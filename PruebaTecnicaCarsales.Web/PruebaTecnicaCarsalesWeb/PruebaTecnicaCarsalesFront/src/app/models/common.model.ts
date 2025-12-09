// src/app/models/common.model.ts

/**
 * Interfaz genérica para la respuesta paginada estandarizada por el BFF.
 * La paginación se maneja con booleanos (hasPrevPage, hasNextPage),
 * simplificando la lógica del Frontend.
 */
export interface BffResponse<T> {
  currentPage: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  hasPrevPage: boolean; 
  hasNextPage: boolean;
  results: T[]; // El listado de la entidad específica (Episode, Character, Location)
}

export interface BaseEntity {
  id: number;
  name: string;
}