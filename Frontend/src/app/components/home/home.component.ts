import {LiveAnnouncer} from '@angular/cdk/a11y';
import {AfterViewInit, Component, ViewChild, OnInit} from '@angular/core';
import {MatSort, Sort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { ContactService } from 'src/app/_sevices/contact.service';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { ContactWithDetailsFilter } from 'src/app/_models/contactwithdetailsfilter';
import { Gender } from 'src/app/_models/gender';




@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  displayedColumns: string[] = ['Id', 'Name', 'Last Name', 'Gender', 'Phone Number' , 'Team' , 'Manager' ,'Options'];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  filter  = {} as ContactWithDetailsFilter;
  skipCount = 0;
  totalRows = 0;
  pageSize = 5;
  currentPage = 0;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  sortingElement: string = 'Id asc';

  anyFilter : string ="";
  name : string ="b";
  lName : string = "";
  teamName : string ="";
  phoneNumber: string ="";
  directBossFullName: string =""; 


  @ViewChild('paginator') paginator!: MatPaginator;

  


  constructor(private _liveAnnouncer: LiveAnnouncer,
              private service : ContactService,
              private router: Router
             ) {

             }

  @ViewChild(MatSort) sorting = new MatSort();

  ngAfterViewInit() {
    
    this.dataSource.sort = this.sorting;
  }

  ngOnInit(): void {

   
    this.getContacts();
    this.dataSource.sort=this.sorting;
   
  }

  getContacts() {

    

    this.service.getContactWithDetailsListFilter(this.anyFilter, this.name,this.lName, this.teamName,this.phoneNumber, this.directBossFullName, this.skipCount, this.pageSize, this.sortingElement).subscribe(data => {

      console.log(data);
      this.dataSource = new MatTableDataSource(data.items);
      this.totalRows = data.totalCount;
               
    }

    );


  }

  // getContacts() {

  //   this.service.getContactWithDetailsList(this.filterText, this.skipCount, this.pageSize, this.sortingElement).subscribe(data => {

  //     console.log(data);
  //     this.dataSource = new MatTableDataSource(data.items);
  //     this.totalRows = data.totalCount;
                     
  //   }

  //   );

  // }
  

 onEdit(contact: any){
   
  this.service.selectedRow = contact.id;
  this.router.navigate(["/editcontact"]);
  this.getContacts();
}

 
  onDelete(id:number)
  {
    if (confirm('Are you sure to delete?')) {
      this.service.deleteContact(id).subscribe(res => {

        this.getContacts();

      })

    }
    
  }

  onSortChanged(sortState: any) {
   
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  applyFilter(event: Event) {
    this.name = (event.target as HTMLInputElement).value;
    this.getContacts();

  }

  pageChanged(event: any) {
    console.log(this.pageSize);
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
  this.getContacts();
  }

  onAdd(){

  }

}
