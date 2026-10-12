import { Component, OnInit, ChangeDetectionStrategy, inject, signal } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Contact } from '../../_models/contact';
import { DirectBoss } from '../../_models/manager';
import { ContactService } from '../../_sevices/contact.service';

@Component({
    selector: 'app-editcontact',
    templateUrl: './editcontact.component.html',
    styleUrls: ['./editcontact.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class EditcontactComponent implements OnInit {

  private service = inject(ContactService);
  private router = inject(Router);

  members = signal<DirectBoss[]>([]);
  contact = signal({} as Contact);
  saving = signal(false);
  saveFailed = signal(false);


  ngOnInit(): void {

    this.loadTeamMmbers();

    this.loadSelectedContact(this.service.selectedRow());
  }

  loadSelectedContact(id: number) {
    this.service.getContactById(id).subscribe(data => {
      this.contact.set(data);
      console.log(this.contact());
    })
  }

  loadTeamMmbers() {


    this.service.getAllTeamMembersList()
      .subscribe(data => {

        this.members.set(data);
        console.log(data);

      }
      );

  }

  updateContact(changes: Partial<Contact>) {

    this.contact.update(contact => ({ ...contact, ...changes }));
  }

  setSelectedManager(e: any) {
    this.updateContact({ directBossId: e });
    console.log(e);

  }

  setSelectedGender(e: any) {
    this.updateContact({ gender: e });
    console.log(e);

  }

  onSubmit(form: NgForm) {

    if (form.invalid || this.saving()) {
      return;
    }

    console.log(this.contact());
    this.saving.set(true);
    this.saveFailed.set(false);
    this.service.editContct(this.contact()).subscribe({
      next: res => {
        console.log(res);
        this.router.navigate(['/']);
      },
      error: () => {
        this.saving.set(false);
        this.saveFailed.set(true);
      }
    });
  }
}
