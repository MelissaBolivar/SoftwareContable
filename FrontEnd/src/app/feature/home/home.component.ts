import { Component, Renderer2, ElementRef } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  constructor(private renderer: Renderer2, private el: ElementRef) {}

  startApp() {
    const button = this.el.nativeElement.querySelector('.start-button');
    if (button) {
      // Añade clase de brillo
      button.classList.add('clicked');

      // Efecto de partículas
      for (let i = 0; i < 10; i++) {
        const spark = this.renderer.createElement('span');
        this.renderer.addClass(spark, 'spark');
        const size = Math.random() * 6 + 4 + 'px';
        this.renderer.setStyle(spark, 'width', size);
        this.renderer.setStyle(spark, 'height', size);
        this.renderer.setStyle(spark, 'left', Math.random() * 100 + '%');
        this.renderer.setStyle(spark, 'top', Math.random() * 100 + '%');
        button.appendChild(spark);

        setTimeout(() => spark.remove(), 800); // desaparecen rápido
      }

      // Quita el brillo luego de la animación
      setTimeout(() => button.classList.remove('clicked'), 600);
    }
  }
}
