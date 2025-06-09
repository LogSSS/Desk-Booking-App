import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  imports: [CommonModule],
})
export class CarouselComponent implements OnInit {
  @Input() images: { src: string; alt?: string }[] = [];
  selectedImage: string = '';
  selectedAlt: string = '';

  ngOnInit(): void {
    if (this.images.length) {
      this.selectedImage = this.images[0].src;
      this.selectedAlt = this.images[0].alt || '';
    }
  }

  selectImage(img: string, alt: string = ''): void {
    this.selectedImage = img;
    this.selectedAlt = alt;
  }
}
