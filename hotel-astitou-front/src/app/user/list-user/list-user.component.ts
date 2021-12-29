import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {User} from "@app/_models";
import { UserService } from '@app/_services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css'],
  
})
export class ListUserComponent implements OnInit {
  loading = false;
  users: User[];

  constructor(private router: Router, private apiService: UserService) { }

  ngOnInit() {
    this.loading = true;
    this.apiService.getAll().pipe(first()).subscribe(users => {
        this.users = users;
      });
  }

  deleteUser(user: User): void {
    this.apiService.deleteUser(user.id)
      .subscribe( data => {
        this.users = this.users.filter(u => u !== user);
      })
  };

  editUser(user: User): void {
    window.localStorage.removeItem("editUserId");
    window.localStorage.setItem("editUserId", user.id.toString());
    this.router.navigate(['edit-user']);
  };

  addUser(): void {
    this.router.navigate(['add-user']);
  };
}