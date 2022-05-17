import { CommentsService } from './../../services/comments.service';
import { UserDetails } from './../../models/userDetails.model';
import { UsersService } from 'src/app/services/users.service';
import { CarsService } from 'src/app/services/cars.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car.model';
import { ImagesService } from 'src/app/services/images.service';
import { ImageUrl } from 'src/app/models/imageUrl';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-car-detailed-view',
  templateUrl: './car-detailed-view.component.html',
  styleUrls: ['./car-detailed-view.component.css']
})
export class CarDetailedViewComponent implements OnInit {
  car: Car = new Car();
  images : ImageUrl[];
  seller : UserDetails;
  comments : Comment[];
  dateCreated : string;
  dateUpdated : string;
  
  constructor(
    private route: ActivatedRoute,
    private carsService: CarsService,
    private imageService : ImagesService,
    private userService: UsersService,
    private commentService : CommentsService
    ) { }

  ngOnInit(): void {
    this.getCar();
  }

  getCar(): void{
    var id = String(this.route.snapshot.paramMap.get('id'));
    this.carsService.getCar(Number(id)).subscribe(event => {
      this.car = event;
      this.dateUpdated = formatDate(this.car.atnaujintasData, 'yyy-MM-dd HH:mm', 'en-US');
      this.dateCreated = formatDate(this.car.sukurimoData, 'yyy-MM-dd HH:mm', 'en-US');

      this.getImages();
      this.getSeller();
      this.getComments();
    });
  }

  getImages(): void {
    this.imageService.getCarImages(this.car.id).subscribe(event => {
      this.images = event;
    });
  }

  getSeller(): void {
    this.userService.getUserById(this.car.userId).subscribe(event => {
      this.seller = event;
    });
  }

  getComments(): void{
    this.commentService.getCommentsById(this.car.id).subscribe(event => {
      this.comments = event;
    });
  }

}
