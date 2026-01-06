 
import { NgIf, NgStyle } from '@angular/common';
import { Component, OnInit, OnChanges, Input, Output, EventEmitter, ElementRef, SimpleChanges } from '@angular/core';
import { DxFileUploaderModule } from 'devextreme-angular/ui/file-uploader';
import notify from 'devextreme/ui/notify';

@Component({
    selector: 'form-photo',
    templateUrl: './form-photo.component.html',
    styleUrls: ['./form-photo.component.scss'],
    standalone: true,
    imports: [
        NgStyle,
        NgIf,
        DxFileUploaderModule, 
    ],
})
export class FormPhotoComponent implements OnInit,OnChanges  {

  @Output() imageUrlChange = new EventEmitter<string>();

  @Input() link: string;

  @Input() editable = false;

  @Input() size = 124;

  imageUrl: string;

  hostRef = this.elRef.nativeElement;

 

  showUploader = false; // DxFileUploader'ı gösterme durumu
  temporaryImageUrl: string; // Geçici resim URL'si

  constructor(private elRef:ElementRef) {}
   
  ngOnChanges(changes: SimpleChanges) {
    // 'showUploader' değişkeninde değişiklik olduğunda çalışacak kod
    if (changes.showUploader && !this.showUploader) {
      this.onUploaderClosed();  // Uploader kapanınca çağrılacak fonksiyon
    }
  }
 
 

  ngOnInit() {
    this.imageUrl = this.link;  // Başlangıçta resmi ayarla
    this.temporaryImageUrl = this.link;  // Başlangıçta geçici resmi ayarla
  }

  toggleUploader() {
    if (this.editable) { 
      this.temporaryImageUrl = this.imageUrl;
      this.showUploader = !this.showUploader; 
    }
  }
  
  
  onFileSelected(event) {
    const files = event.value;
    if (files && files.length > 0) {
        const file = files[0];
        const validExtensions = ['jpg', 'jpeg', 'png'];
        const fileExtension = file.name.split('.').pop().toLowerCase();
        const maxSize = 2 * 1024 * 1024; // 2 MB

            // Dosya boyutunu kontrol et
            if (file.size > maxSize) {
              notify({
                  message: 'File size should not exceed 2 MB.',
                  position: { at: 'bottom center', my: 'bottom center' }
              }, 'error');
              return; // Dosya boyutu sınırı aşılırsa işlemi sonlandır
          }

        // Dosya uzantısını kontrol et
        if (!validExtensions.includes(fileExtension)) {
            notify({
                message: 'Unsupported file format. Please upload a JPEG or PNG image.',
                position: { at: 'bottom center', my: 'bottom center' }
            }, 'error');
            return; // Uygun olmayan dosya formatında işlemi sonlandır
        }

    

        const reader = new FileReader();
        reader.onload = (e: any) => {
            this.imageUrl = e.target.result;
            this.imageUrlChange.emit(this.imageUrl);
            this.showUploader = false;
        };
        reader.onerror = (e) => {
            console.error('Error reading file:', e);
            notify({
                message: 'Error reading file. Please try again.',
                position: { at: 'bottom center', my: 'bottom center' }
            }, 'error');
        };
        reader.readAsDataURL(file);
    } else { 
        this.imageUrl = this.temporaryImageUrl;
        this.showUploader = false;
    }
}
 
  onUploaderClosed() {
    // Uploader kapatıldığında yapılacak işlemler
    this.imageUrl = this.temporaryImageUrl;
    this.showUploader = false;
    console.log('Uploader has been closed.');
  }
 
}

 