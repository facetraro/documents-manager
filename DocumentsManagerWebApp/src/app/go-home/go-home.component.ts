import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-go-home',
  templateUrl: './go-home.component.html',
  styleUrls: ['./go-home.component.css']
})
export class GoHomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  goHome(){
    this.router.navigate((['/home']));
   }
}
