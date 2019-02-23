import React from 'react';
import styles from './styles.css';
import Cell from '../Cell';
import Tile from '../Tile';


export default class Field extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            //fieldState: this.props.fieldState
        };
    }
    render() {

        let cells = [[]];
        if (!(Object.entries(this.props.fieldState).length === 0 && this.props.fieldState.constructor === Object)) {


            for (let i = 0; i < 4; i++) {

                let row = [];

                for (let j = 0; j < 4; j++) {

                    let val = this.props.fieldState[i][j];

                    row.push(<Cell y={i} x={j}>
                        {val > 0 ?
                            <Tile value={val} /> : null}
                    </Cell>);
                }

                cells.push(row);
            }
        }
        return (
            <div>
                <div className={styles.root}>
                    {cells}
                </div>

            </div>
        );
    }
}
