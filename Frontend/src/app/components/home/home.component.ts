import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ChangeDetectionStrategy, computed, inject, signal } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { ContactService } from '../../_sevices/contact.service';
import { ContactWithDetails } from '../../_models/contactwithdetails';
import { ContactWithDetailsFilter } from '../../_models/contactwithdetailsfilter';




@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})

export class HomeComponent implements OnInit {

  private _liveAnnouncer = inject(LiveAnnouncer);
  private service = inject(ContactService);
  private router = inject(Router);

  readonly displayedColumns: string[] = ['Id', 'Name', 'LName', 'Gender', 'PhoneNumber', 'TeamName', 'DirectBossFullName', 'Options'];
  readonly pageSizeOptions: number[] = [5, 10, 25, 100];

  contacts = signal<ContactWithDetails[]>([]);
  totalRows = signal(0);
  pageSize = signal(5);
  currentPage = signal(0);
  sortingElement = signal('Id asc');

  filterText = signal("");
  filter = signal({

    name: "",
    lName: "",
    teamName: "",

  } as ContactWithDetailsFilter);

  skipCount = computed(() => this.currentPage() * this.pageSize());
  filterIsActiv = computed(() => {
    const filter = this.filter();
    return !!(filter.name || filter.lName || filter.teamName || this.filterText());
  });


  ngOnInit(): void {

    this.getContactsAnyFilter();

  }


  getContactsAnyFilter() {

    this.service.getContactWithAnyFilter(this.filterText(), this.skipCount(), this.pageSize(), this.sortingElement()).subscribe(data => {

      console.log(data);
      this.totalRows.set(data.totalCount);
      this.contacts.set(data.items);

    }

    );

  }

  getContactsWithSpecificFilter() {

    console.log(this.filter());
    this.service.getContactWithSpecificFilter(this.filter(), this.skipCount(), this.pageSize(), this.sortingElement()).subscribe(data => {

      console.log(data);
      this.totalRows.set(data.totalCount);
      this.contacts.set(data.items);

    }

    );

  }

  onEdit(contact: ContactWithDetails) {

    this.service.selectedRow.set(contact.id);
    this.router.navigate(["/editcontact"]);
    this.getContactsAnyFilter();

  }


  onDelete(id: number) {
    if (confirm('Are you sure to delete?')) {
      this.service.deleteContact(id).subscribe(res => {

        this.getContactsAnyFilter();

      })

    }

  }

  onSortChanged(sortState: Sort) {

    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
      this.sortingElement.set(sortState.active + ' ' + sortState.direction);
      this.currentPage.set(0);
      this.getContactsAnyFilter();

    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  applyFilter(filterText: string) {

    this.filterText.set(filterText);
    this.getContactsAnyFilter();

  }

  applySpecificFilter(changes: Partial<ContactWithDetailsFilter>) {

    this.filter.update(filter => ({ ...filter, ...changes }));
    this.getContactsWithSpecificFilter();

  }

  pageChanged(event: PageEvent) {
    if (this.pageSize() != event.pageSize) {
      this.pageSize.set(event.pageSize);
      this.currentPage.set(0);
    }
    else {
      this.currentPage.set(event.pageIndex);

    }
    this.getContactsAnyFilter();
  }

  clearFilters() {

    this.emptyFilters();
    this.getContactsAnyFilter();


  }
  emptyFilters() {
    this.filterText.set("");
    this.filter.update(filter => ({ ...filter, name: "", lName: "", teamName: "" }));
  }

}
