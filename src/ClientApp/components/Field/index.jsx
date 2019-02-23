import React from 'react';
import styles from './styles.css';
import Cell from '../Cell';
import Tile from '../Tile';


export default class Field extends React.Component {
    render() {

        let cells = [[]];

        for (let i = 0; i < 4; i++) {

            let row = [];

            for (let j = 0; j < 4; j++) {

                row.push(<Cell x={i} y={j}><Tile value={2} /></Cell>);
            }

            cells.push(row);
        }

        console.log(cells);
        return (
            <div>
            <div className={styles.root}>
                {cells}
                </div>
                
            </div>
        );
    }
}
