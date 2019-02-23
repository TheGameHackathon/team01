import React from 'react';
import styles from './styles.css';

export default class Tile extends React.Component {

    constructor(props) {
        super(props);
        this.state = { value: this.props.value};
    }

    render() {

        
        
        return (
            <div className={`${styles.tile} ${styles.tile2}`}>
                {this.state.value}
            </div>
        );
    }
}
