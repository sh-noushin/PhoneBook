import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../_models/contact';
import { ContactWithDetailsFilter } from '../_models/contactwithdetailsfilter';


@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  readonly APIUrl = 'https://localhost:7279/';
  selectedRow : number = 0;

  // getContactWithDetailsList(): Observable<any> {
    
  //   return this.http.get<any>(this.APIUrl + 'Contact/withdetails');
  

  // }

  // getContactWithDetailsList(filterText: string, skipCount: number, maxResultCount: number, sorting: string): Observable<any> {
    
  //   return this.http.get<any>(this.APIUrl + 'Contact/details?FilterText=' + filterText + '&SkipCount=' +
  //   skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
  

  // }
  // getContactWithDetailsListFilter(filter: ContactWithDetailsFilter, skipCount: number, maxResultCount: number, sorting: string): Observable<any> {
    
  //   return this.http.get<any>(this.APIUrl + 'Contact/details?AnyFilter=' + "m" +'&Name=' +"d"+ '&SkipCount=' +
  //   skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
  

  // }

  getContactWithDetailsListFilter(anyFilter : string, name : string, lName : string, 
    teamName : string, phoneNumber: string, directBossFullName: string, skipCount: number, maxResultCount: number, sorting: string): Observable<any> {
    
    return this.http.get<any>(this.APIUrl + 'Contact/details?AnyFilter=' + anyFilter +'&Name=' + name + '&LName=' + lName +
    '&PhoneNumber=' + phoneNumber + '&TeamName=' + teamName + '&DirectBossFullName=' + directBossFullName + '&SkipCount=' +
    skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
    // return this.http.get<any>(this.APIUrl + 'Contact/details?AnyFilter=' + anyFilter  + '&SkipCount=' +
    // skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
  

  }
  getAllTeamMembersList(): Observable<any> {
    
    return this.http.get<any>(this.APIUrl + 'TeamMember');
  

  }

  addNewContact(contact: Contact): Observable<any> {

    return this.http.post(this.APIUrl + 'Contact', contact,
      { responseType: 'text' });
  }

  deleteContact(id: number): Observable<any> {
    return this.http.delete(this.APIUrl + 'Contact/' + id, { responseType: 'text' });
  }

  getContactById(id : number): Observable<any>
  {
    return this.http.get<any>(this.APIUrl + 'Contact/' + id);
  }

  editContct(contact : any): Observable<any>
  {
   return this.http.put<any>(this.APIUrl + 'Contact/' + contact.id, contact);
   
  }

}
