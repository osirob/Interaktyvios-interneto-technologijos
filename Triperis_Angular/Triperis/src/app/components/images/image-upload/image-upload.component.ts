import { ImagesService } from './../../../services/images.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.css']
})
export class ImageUploadComponent implements OnInit {
  public message: string;
  public loading: boolean;
  files : File[] = [];
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private imagesService : ImagesService) { }

  ngOnInit(): void {
  }

  onUpload() {
    if(this.files.length === 0){
      return;
    }
    this.loading = !this.loading;
    let filesToUpload = <File[]>this.files;
  
    //let fileToUpload = <File>this.files[0];
    var formData = new FormData();

    let index: Number = 0;

    for(let file of filesToUpload){
      formData.append('files', file);
    }
    
    console.log(formData.getAll('files'));

    //formData.append('file', filesToUpload);
    this.imagesService.uploadImage(formData, 1).subscribe( response =>{
      if(response.type === HttpEventType.Response){
        console.log('IT WORKED HAAAAAAAAAAAAAAAAAAAAAAAAAAA');
      }
    });
  }

  onChange(event){
    this.files = event.target.files;
  }

}