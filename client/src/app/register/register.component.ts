import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }
  register(){
    this.accountService.register(this.model).subscribe(response => {
      
    }, error=>{
      console.log(error);
    });
  }

}
