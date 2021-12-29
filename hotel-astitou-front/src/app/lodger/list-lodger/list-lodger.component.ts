import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {Lodger} from "@app/_models";
import { LodgerService } from '@app/_services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-list-lodger',
  templateUrl: './list-lodger.component.html',
  styleUrls: ['./list-lodger.component.css'],
  
})
export class ListLodgerComponent implements OnInit {
  loading = false;
  lodgers: Lodger[];
  test: string;

  constructor(private router: Router, private apiService: LodgerService) { }

  ngOnInit() {
    this.loading = true;
    this.test="test";
    this.apiService.getAll().pipe(first()).subscribe(lodgers => {
      this.loading = false;
        this.lodgers = lodgers;
      });
  }

  
  deleteLodger(lodger: Lodger): void {
    this.apiService.deleteLodger(lodger.id)
      .subscribe( data => {
        this.lodgers = this.lodgers.filter(l => l !== lodger);
      })
  };

  editLodger(lodger: Lodger): void {
    window.localStorage.removeItem("editlodgerId");
    window.localStorage.setItem("editlodgerId", lodger.id.toString());
    this.router.navigate(['edit-lodger']);
  };

  addLodger(): void {
    this.router.navigate(['add-lodger']);
  };
}