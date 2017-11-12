import { Person } from './Person';
export class Question {
    ID: number;
    Person: Person;
    Quest: string;
    QuestionType: string; //Question is string so backend can validate if category exists or not.
    Answer: string;
}