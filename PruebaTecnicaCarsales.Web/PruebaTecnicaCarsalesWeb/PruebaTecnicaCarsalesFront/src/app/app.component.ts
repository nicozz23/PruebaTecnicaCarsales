// src/app/app.component.ts

import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListViewComponent } from './components/list-view/list-view.component';

@Component({
  selector: 'app-root',
  standalone: true,
  // Importamos el componente de listado y CommonModule para usar [class.active] y @if
  imports: [ListViewComponent, CommonModule], 
  template: `
    <header class="main-header">
      <h1>Rick and Morty world </h1>
    </header>
    <main class="main-content">
      <nav class="tabs">
        <button [class.active]="currentView() === 'episodes'" (click)="currentView.set('episodes')">Episodios</button>
        <button [class.active]="currentView() === 'characters'" (click)="currentView.set('characters')">Personajes</button>
        <button [class.active]="currentView() === 'locations'" (click)="currentView.set('locations')">Locaciones</button>
      </nav>

      <div class="view-area">
        @if (currentView() === 'episodes') {
          <app-list-view entityType="episodes" />
        } @else if (currentView() === 'characters') {
          <app-list-view entityType="characters" />
        } @else if (currentView() === 'locations') {
          <app-list-view entityType="locations" />
        }
      </div>
    </main>
  `,
  // Estilos básicos para la presentación
  styleUrls: [ './app.component.css']

})
export class AppComponent {
  // Signal para manejar el estado de la vista activa
  currentView = signal<'episodes' | 'characters' | 'locations'>('episodes');
}