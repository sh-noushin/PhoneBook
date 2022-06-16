import { LiveAnnouncer } from '@angular/cdk/a11y';
import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatSort, Sort } from '@angular/material/sort';import { MatTableDataSource } from '@angular/material/table';
import { ContactService } from 'src/app/_sevices/contact.service';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { ContactWithDetailsFilter } from 'src/app/_models/contactwithdetailsfilter';




@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  displayedColumns: string[] = ['Id', 'Name', 'LName', 'Gender', 'PhoneNumber', 'TeamName', 'DirectBossFullName', 'Options'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  filterIsActiv: boolean = false;
  skipCount = 0;
  totalRows = 0;
  pageSize = 5;
  currentPage = 0;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  sortingElement: string = 'Id asc';

  filterText: string = "";

  filter = {

    name: "",
    lName: "",
    teamName: "",


  } as ContactWithDetailsFilter;
  anyFilter: string = "";
  name: string = "";
  lName: string = "";
  teamName: string = "";


  @ViewChild('paginator') paginator!: MatPaginator;
  @ViewChild(MatSort) sorting = new MatSort();

  constructor(private _liveAnnouncer: LiveAnnouncer,
    private service: ContactService,
    private router: Router
  ) {

  }


  ngAfterViewInit() {

    this.dataSource.sort = this.sorting;
  }

  ngOnInit(): void {


    this.getContactsAnyFilter();
    this.dataSource.sort = this.sorting;

  }


  getContactsAnyFilter() {

    this.service.getContactWithAnyFilter(this.filterText, this.skipCount, this.pageSize, this.sortingElement).subscribe(data => {

      console.log(data);
      this.totalRows = data.totalCount;
      this.dataSource = new MatTableDataSource(data.items);

    }

    );

  }

  getContactsWithSpecificFilter() {

    console.log(this.filter);
    this.service.getContactWithSpecificFilter(this.filter, this.skipCount, this.pageSize, this.sortingElement).subscribe(data => {

      console.log(data);
      this.totalRows = data.totalCount;
      this.dataSource = new MatTableDataSource(data.items);

    }

    );

  }

  onEdit(contact: any) {

    this.service.selectedRow = contact.id;
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

  onSortChanged(sortState: any) {

    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
      this.sortingElement = sortState.active + ' ' + sortState.direction;
      this.paginator.pageIndex = 0;
      this.currentPage = this.paginator.pageIndex;

      this.pageSize = this.paginator.pageSize;
      this.skipCount = this.currentPage * this.pageSize;
      this.paginator.firstPage();
      this.getContactsAnyFilter();

    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  applyFilter(event: Event) {

    this.showOrHideClearFilterBtn();
    this.filterText = (event.target as HTMLInputElement).value;
    this.getContactsAnyFilter();

  }
  applyFilterName(event: Event) {


    this.filter.name = (event.target as HTMLInputElement).value;
    this.name = (event.target as HTMLInputElement).value;

    this.getContactsWithSpecificFilter();
    this.showOrHideClearFilterBtn();
  }
  applyFilterLName(event: Event) {


    this.filter.lName = (event.target as HTMLInputElement).value;
    this.lName = (event.target as HTMLInputElement).value;

    this.getContactsWithSpecificFilter();
    this.showOrHideClearFilterBtn();
  }
  applyFilterTeam(event: Event) {


    this.filter.teamName = (event.target as HTMLInputElement).value;
    this.teamName = (event.target as HTMLInputElement).value;

    this.name = (event.target as HTMLInputElement).value;

    this.getContactsWithSpecificFilter();
    this.showOrHideClearFilterBtn();
  }

  pageChanged(event: any) {
    if (this.pageSize != event.pageSize) {
      this.paginator.pageIndex = 0;
      this.pageSize = event.pageSize;
      this.currentPage = this.paginator.pageIndex;
      this.paginator.firstPage();
    }
    else {
      this.currentPage = event.pageIndex;

    }
    this.skipCount = this.currentPage * this.pageSize;
    this.getContactsAnyFilter();
  }

  showOrHideClearFilterBtn() {
    if (this.filter.name || this.filter.lName || this.filter.teamName || this.filterText) {
      this.filterIsActiv = true;
    }
  }

  clearFilters() {

    this.emptyFilters();
    this.filterIsActiv = false;
    this.getContactsAnyFilter();


  }
  emptyFilters() {
    this.filterText = "";
    this.filter.name = "";
    this.filter.lName = "";
    this.filter.teamName = "";
  }

}
