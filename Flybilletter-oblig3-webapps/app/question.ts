import { Person } from './Person';
import { QuestionCategory } from './QuestionCategory';

export class Question {
    ID: number;
    Person: Person;
    Quest: string;
    Category: QuestionCategory; //Question is string so backend can validate if category exists or not.
    Answer: string;
}

export class QuestionData {
    Person: Person;
    Quest: string;
    Category: string;
    Answer: string;
}