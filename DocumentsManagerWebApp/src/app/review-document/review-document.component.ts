import { Component, OnInit } from '@angular/core';
import { Review } from './review';
import { ReviewService } from './review.service';
import { ManageToken } from '../manage-token';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-review-document',
  templateUrl: './review-document.component.html',
  styleUrls: ['./review-document.component.css']
})
export class ReviewDocumentComponent implements OnInit {
  tokenManagment:ManageToken;
  review:Review;
  reviewValues = [
    {id: 0, name: "0 : ☆☆☆☆☆"},
    {id: 1, name: "1 : ★☆☆☆☆"},
    {id: 2, name: "2 : ★★☆☆☆"},
    {id: 3, name: "3 : ★★★☆☆"},
    {id: 4, name: "4 : ★★★★☆"},
    {id: 5, name: "5 : ★★★★★"}
  ];
  constructor(private reviewService : ReviewService,  private activatedRoute: ActivatedRoute, private router: Router) { 
      this.review=new Review;
      this.tokenManagment=new ManageToken;
  }
  addReview(){
    this.reviewService.newReview(this.tokenManagment.getToken(),this.review).subscribe(response => this.addReviewOk()), 
    error => this.showErrorMessage(error);
  }

  addReviewOk(){
    alert("Reseña añadida correctamente");
    this.router.navigate((['/friends']));
  }

  showErrorMessage(error:any){
    alert(error);
  }
  ngOnInit() {
    this.activatedRoute.queryParams
    .filter(params => params.idDoc)
    .subscribe(params => {
      this.review.commentedId = params.idDoc;
    });  
  }
}
