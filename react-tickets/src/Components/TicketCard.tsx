import React, { useCallback } from 'react';
import { Ticket } from '../types/Ticket';

interface TicketCardProps {
    ticket: Ticket;
    onHandle: (id: number) => void;
    onDelete: (id: number) => void;
} 

const TicketCard: React.FC<TicketCardProps> = ({ticket, onHandle, onDelete}) => {
    const handleClick = useCallback(() => {
        onHandle(ticket.id);
    }, [onHandle, ticket.id]);

    const deleteClick = useCallback(() => {
        onDelete(ticket.id);
    }, [onDelete, ticket.id]);

    return (
        <div key={ticket.id} className="col-md-4">
            <div className={ticket.status === 'Handled' ? "card border-success mb-4" : "card border-danger mb-4"}>
                <div className={ticket.status === 'Handled' ? "card-body text-success" : "card-body text-danger"}>
                    <p className="card-text">{ticket.user}</p>
                    <p className="card-text">{ticket.complaintDescription}</p>
                </div>
                <div className="card-footer bg-transparent">
                    <button type="button" disabled={ticket.status === 'Handled'} onClick={handleClick} className="btn btn-sm btn-outline-secondary">Handle</button>
                    <button type="button" onClick={deleteClick} className="btn btn-sm btn-outline-danger">Delete</button>
                </div>
            </div>
         </div>
    );
};

export default TicketCard;