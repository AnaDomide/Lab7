import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { UserRoleService } from 'src/app/services/userRole.service';

@Component({
  selector: 'app-userRole',
  templateUrl: './userRole.component.html',
  styleUrls: ['./userRole.component.scss']
})
export class UserRoleComponent implements OnInit {

    public userRoles: any = null;
    public displayedColumns: string[] = ['name', 'description'];

  constructor(private userRoleService: UserRoleService, private router :Router) {
      this.getAllUserRoles();
  }

  ngOnInit() {

  }

  getAllUserRoles(){
      this.userRoleService.getAllUserRoles().subscribe(ur => {
          this.userRoles = ur;
          console.log(ur);
      })
  }

  goBack(){
    this.router.navigate(['']);
  }

}