import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateTransaction, TransactionsService } from '../../services/transaction.service';

@Component({
  selector: 'app-transaction-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './transaction-form.component.html',
})
export class TransactionFormComponent {
  private transactionsService = inject(TransactionsService);

  transactionForm = new FormGroup({
    description: new FormControl('', {
      validators: [Validators.required],
    }),
    amount: new FormControl(0.0, {
      validators: [Validators.required, Validators.min(0.01)],
    }),
    date: new FormControl(new Date().toISOString().split('T')[0], {
    }),
    category: new FormControl('Others'),
    type: new FormControl('Expense')
  });

  submit(): void {
    if (this.transactionForm.invalid) {
      return;
    }

    const { description, amount, date, category, type } = this.transactionForm.value;
    const t: CreateTransaction = {
      description: description ?? '',
      amount: amount ?? 0,
      date: date ?? new Date().toISOString(),
      transactionType: category ?? 'Others',
      transactionCategory: type ?? 'Expense',
    };
    this.transactionsService.createTransactions(t).subscribe({
      next: (response) => {
        console.log('Transaction criada:', response);
        window.location.reload();
      },
      error: (error) => {
        console.error('Erro ao criar transaction:', error);
      },
    });
  }
}
