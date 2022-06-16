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

    
  getContactWithAnyFilter(filterText: string, skipCount: number, maxResultCount: number, sorting: string): Observable<any> {
    console.log("filterText is " + filterText);
    if(this.isEmptyOrSpaces(filterText))
    {
      return this.http.get<any>(this.APIUrl + 'Contact/details?SkipCount=' +
    skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
    }

    return this.http.get<any>(this.APIUrl + 'Contact/details?AnyFilter=' + filterText + '&SkipCount=' +
    skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
      
  }

  
  getContactWithSpecificFilter(filter: ContactWithDetailsFilter, skipCount: number, maxResultCount: number, sorting: string): Observable<any> {
        
         
    if(!this.isEmptyOrSpaces(filter.name) && this.isEmptyOrSpaces(filter.lName) && this.isEmptyOrSpaces(filter.teamName))
    {
      return this.http.get<any>(this.APIUrl + 'Contact/details?Name=' + filter.name + '&SkipCount=' +
      skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
    }
    if(!this.isEmptyOrSpaces(filter.name) && !this.isEmptyOrSpaces(filter.lName) && this.isEmptyOrSpaces(filter.teamName))
    {
      return this.http.get<any>(this.APIUrl + 'Contact/details?Name=' + filter.name + 
    '&LName=' + filter.lName + '&SkipCount=' + skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
    }
    if(!this.isEmptyOrSpaces(filter.name) && !this.isEmptyOrSpaces(filter.lName) && !this.isEmptyOrSpaces(filter.teamName))
    {
      return this.http.get<any>(this.APIUrl + 'Contact/details?Name=' + filter.name + 
      '&LName=' + filter.lName + '&TeamName=' + filter.teamName + '&SkipCount=' +
      skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
    }
    if(!this.isEmptyOrSpaces(filter.name) && this.isEmptyOrSpaces(filter.lName) && !this.isEmptyOrSpaces(filter.teamName))
    {
      return this.http.get<any>(this.APIUrl + 'Contact/details?Name=' + filter.name 
      +'&TeamName=' + filter.teamName + '&SkipCount=' +
      skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
    }

    if(this.isEmptyOrSpaces(filter.name) && !this.isEmptyOrSpaces(filter.lName) && !this.isEmptyOrSpaces(filter.teamName))
    {
      return this.http.get<any>(this.APIUrl + 'Contact/details?LName=' + filter.lName 
      +'&TeamName=' + filter.teamName + '&SkipCount=' +
      skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
    }

    return this.http.get<any>(this.APIUrl + 'Contact/details/anyfilter?SkipCount=' +
    skipCount + '&MaxResultCount=' + maxResultCount + '&Sorting=' + sorting);
      
   
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

   isEmptyOrSpaces(str : string){
    return str === null || str.match(/^ *$/) !== null;
}
}
