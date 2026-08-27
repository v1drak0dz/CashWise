import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import type { Transaction } from '../models/transaction';

export interface CreateTransaction {
  description: string;
  amount: number;
  date: string;
  transactionType: string;
  transactionCategory: string;
}

@Injectable({ providedIn: 'root' })
export class TransactionsService {
  private http = inject(HttpClient);

  getTransactions() {
    return this.http.get<Transaction[]>('https://localhost:7289/transactions');
  }

  createTransactions(transaction: CreateTransaction) {
    return this.http.post('https://localhost:7289/transactions', transaction);
  }
}
