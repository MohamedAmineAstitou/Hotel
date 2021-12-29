import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {Guarantor} from "@app/_models";
import { GuarantorService } from '@app/_services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-list-guarantor',
  templateUrl: './list-guarantor.component.html',
  styleUrls: ['./list-guarantor.component.css'],
  
})
export class ListGuarantorComponent implements OnInit {
  loading = false;
  guarantors: Guarantor[];
  test: string;

  constructor(private router: Router, private apiService: GuarantorService) { }

  ngOnInit() {
    this.loading = true;
    this.test="test";
    this.apiService.getAll().pipe(first()).subscribe(guarantors => {
      this.loading = false;
        this.guarantors = guarantors;
      });
  }

  
  deleteGuarantor(guarantor: Guarantor): void {
    this.apiService.deleteGuarantor(guarantor.id)
      .subscribe( data => {
        this.guarantors = this.guarantors.filter(l => l !== guarantor);
      })
  };

  editGuarantor(guarantor: Guarantor): void {
    window.localStorage.removeItem("editGuarantorId");
    window.localStorage.setItem("editGuarantorId", guarantor.id.toString());
    this.router.navigate(['edit-guarantor']);
  };
}