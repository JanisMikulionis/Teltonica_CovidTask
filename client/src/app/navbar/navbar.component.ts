import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
      
    }, error=>{
      console.log(error);
    });
  }

  logout(){
    this.accountService.logout();
  }
}
