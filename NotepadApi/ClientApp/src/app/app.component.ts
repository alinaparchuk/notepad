import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Note } from './note';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    note: Note = new Note();   
    notes: Note[];               
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadNotes();   
    }
    // получаем данные через сервис
    loadNotes() {
        this.dataService.getNotes()
            .subscribe((data: Note[]) => this.notes = data);
    }
    // сохранение данных
    save() {
        if (this.note.id == null) {
            this.dataService.createNote(this.note)
                .subscribe((data: Note) => this.notes.push(data));
        } else {
            this.dataService.updateNote(this.note)
                .subscribe(data => this.loadNotes());
        }
        this.cancel();
    }
    editNote(n: Note) {
        this.note = n;
    }
    cancel() {
        this.note = new Note();
        this.tableMode = true;
    }
    delete(n: Note) {
        this.dataService.deleteNote(n.id)
            .subscribe(data => this.loadNotes());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}