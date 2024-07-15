import { AbstractControl } from "@angular/forms";

export class ErrorMessages {
  static  getErrorMessage(fc: AbstractControl) {
    if (fc.errors['required']) {
      return 'Полето е задолжително';
    }
    if (fc.errors['maxLength']) {
      return 'Ја надминавте максималната должина';
    }
    if (fc.errors['email']) {
      return 'Внесете валидна емаил адреса';
    }
    if (fc.errors['oldPasswordRequired']) {
      return 'Невалидна лозинка';
    }
    if (fc.errors['passwordMatch']) {
      return 'Лозинките не се совпаѓаат';
    }
    if (fc.errors['wrongFormat']) {
      return 'Невалиден формат';
    }
    return '';
  }
}
