import { Component, OnInit, signal, WritableSignal, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';

// ** Asegúrate de que estas rutas sean correctas para tu proyecto **

import { BffResponse } from '../../models/common.model';
import { Episode } from '../../models/episode';
import { Character } from '../../models/character';
import { Location } from '../../models/location'; // ⬅️ CORRECCIÓN: Faltaba esta importación
import { DataService } from '../../services/data.service';


// Definimos los tipos para la tipificación correcta del componente
type ItemType = Episode | Character | Location; 
type EntityType = 'episodes' | 'characters' | 'locations';

@Component({
  selector: 'app-list-view',
  standalone: true,
  imports: [CommonModule], 
  templateUrl: './list-view.component.html',
  styleUrls: ['./list-view.component.css']
})
export class ListViewComponent implements OnInit {

  // Input: Define qué tipo de datos cargaremos. Por defecto, 'episodes'.
  @Input() entityType: EntityType = 'episodes'; 
  
  // Signals para el listado de datos
  itemsSignal: WritableSignal<ItemType[]> = signal([]);
  
  // Signals para el estado (Carga y Errores)
  loading: WritableSignal<boolean> = signal(false);
  errorMessage: WritableSignal<string | null> = signal(null);
  
  // Signals para la paginación (basadas en BffResponse)
  currentPage: WritableSignal<number> = signal(1);
  totalPages: WritableSignal<number> = signal(1); 
  hasPrevPage: WritableSignal<boolean> = signal(false);
  hasNextPage: WritableSignal<boolean> = signal(false);


/**
     * Type Guard para Episode. 
     * Si entityType es 'episodes', retorna el item tipificado como Episode, 
     * lo que hace que sus propiedades específicas sean accesibles.
     */
    asEpisode(item: ItemType): Episode | null {
        if (this.entityType === 'episodes') {
            return item as Episode;
        }
        return null;
    }

    /**
     * Type Guard para Character. 
     */
    asCharacter(item: ItemType): Character | null {
        if (this.entityType === 'characters') {
            return item as Character;
        }
        return null;
    }

    /**
     * Type Guard para Location. 
     */
    asLocation(item: ItemType): Location | null {
        if (this.entityType === 'locations') {
            return item as Location;
        }
        return null;
    }
  constructor(private apiService: DataService) { }

  ngOnInit(): void {
    this.loadData();
  }

  /**
   * Carga los datos de la entidad actual (Episode, Character o Location)
   * utilizando la página actual (currentPage).
   */
  loadData(): void {
    // 1. Resetear el estado de carga
    this.loading.set(true);
    this.errorMessage.set(null);
    this.itemsSignal.set([]);

    let apiObservable: Observable<any>; // Usamos 'any' aquí para la respuesta sin tipado estricto de 'results'

    // 2. Seleccionar el Observable de la API
    switch (this.entityType) {
        case 'episodes':
            apiObservable = this.apiService.getEpisodes(this.currentPage());
            break;
        case 'characters':
            apiObservable = this.apiService.getCharacters(this.currentPage());
            break;
        case 'locations':
            apiObservable = this.apiService.getLocations(this.currentPage());
            break;
        default:
            this.errorMessage.set(`Tipo de entidad '${this.entityType}' no soportado.`);
            this.loading.set(false);
            return;
    }

    // 3. Suscribirse y manejar la respuesta
    apiObservable.subscribe({
        next: (response: any) => { // Usamos 'any' temporalmente para acceder a las propiedades dinámicas
            
            // 💡 CORRECCIÓN CLAVE: Acceder al array de datos usando la propiedad dinámica (episodes, characters, o locations)
            const dataArray = response[this.entityType]; 
            
            if (dataArray) {
                this.itemsSignal.set(dataArray as ItemType[]);
            } else {
                // Esto maneja el caso donde, por ejemplo, los datos de episodios llegan como 'episodes'
                // pero si 'response.results' existiera (como en la interfaz BffResponse), usamos ese.
                this.itemsSignal.set(response.results || [] as ItemType[]);
            }

            // Actualizar Signals de Paginación (estas propiedades sí son consistentes)
            this.hasPrevPage.set(response.hasPrevPage);
            this.hasNextPage.set(response.hasNextPage);
            this.totalPages.set(response.totalPages);
            console.log('items signal:', this.itemsSignal());
            console.log(`Datos de ${this.entityType} cargados:`, response);
            this.loading.set(false);
        },
        error: (err) => {
            console.error(`Error al obtener ${this.entityType}:`, err);
            this.errorMessage.set(`No se pudieron cargar los datos de ${this.entityType}.`);
            this.loading.set(false);
        }
    });
  }

/**
   * Cambia la página de la lista, verificando si la navegación es posible.
   * @param direction -1 para anterior, 1 para siguiente.
   */
  changePage(direction: number): void {

    // 1. Verificar si la navegación es posible (si los botones no están deshabilitados)
    if (direction < 0 && !this.hasPrevPage()) {
        return;
    }
    if (direction > 0 && !this.hasNextPage()) {
        return;
    }

    // 2. 🚀 CORRECCIÓN CLAVE: Actualizar la señal de la página actual
    // Sumamos la dirección (-1 o +1) al valor actual.
    this.currentPage.update(current => current + direction);

    // 3. Recargar los datos con la nueva página
    // loadData() usa internamente el valor actualizado de this.currentPage()
    this.loadData();
  }

  
}